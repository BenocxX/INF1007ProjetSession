import { Link, createFileRoute, useParams } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { fetchMenuItemById, updateMenuItem } from "../../../api/menuItems";
import Input from "../../../components/form/input";
import { object, string, number, boolean } from "yup";

export const Route = createFileRoute("/menuItem/$menuItemId/edit")({
  component: Edit,
  staleTime: 0,
});

function Edit() {
  const { menuItemId } = useParams({ strict: false });
  let [id, setId] = useState(menuItemId);
  let [name, setName] = useState("");
  let [description, setDescription] = useState("");
  let [price, setPrice] = useState("");
  let [available, setAvailable] = useState(false);
  const [errors, setErrors] = useState({});

  useEffect(() => {
    setId(parseInt(menuItemId, 10));

    fetchItem(id);
  }, [menuItemId]);

  const validationSchema = object().shape({
    name: string().required(),
    description: string().required(),
    price: number().required(),
    available: boolean().required(),
  });

  const fetchItem = async (id: number) => {
    const data = await fetchMenuItemById(id);
    setName(data.name);
    setDescription(data.description);
    setPrice(data.price);
    setAvailable(data.available);
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      name: name,
      description: description,
      price: price,
      available: available,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
      const response = await updateMenuItem(id, formData);
      console.log(response);
    } catch (validationErrors: any) {
      const formattedErrors: Array<any> = [];
      validationErrors.inner.forEach((error: any) => {
        formattedErrors[error.path] = error.message;
      });
      setErrors(formattedErrors);
    }

    if (errors.length == 0) {
      await updateMenuItem(parseInt(menuItemId, 10), formData);
    }
  };

  const handleToggleChange = (e: any) => {
    setAvailable(e.target.checked);
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-6 max-w-md mx-auto">
      <h1 className="text-center text-3xl mb-4">Ajouter un plat</h1>
      <form
        method="put"
        action={import.meta.env.BASE_URL + "/menu/" + menuItemId}
        onSubmit={handleSubmit}
      >
        <div className="mb-4">
          <Input
            name="name"
            placeholder="Nom du plat"
            value={name}
            onChange={setName}
            errors={errors}
          />
        </div>
        <div className="mb-4">
          <Input
            name="description"
            placeholder="Description"
            value={description}
            onChange={setDescription}
            errors={errors}
          />
        </div>
        <div className="mb-4">
          <Input
            name="price"
            placeholder="Prix"
            type="number"
            value={price}
            onChange={setPrice}
            errors={errors}
          />
        </div>
        <div className="form-control">
          <label className="label cursor-pointer">
            <span className="label-text">Afficher sur le menu</span>
            <input
              type="checkbox"
              className="toggle"
              checked={available}
              onChange={handleToggleChange}
            />
          </label>
        </div>
        <div className="flex justify-end">
          <Link to="/menu/create" type="button" className="btn btn-light m-4">
            Annuler
          </Link>
          <button
            onClick={handleSubmit}
            type="submit"
            className="btn btn-success mt-4 text-white"
          >
            Soummettre
          </button>
        </div>
      </form>
    </div>
  );
}
