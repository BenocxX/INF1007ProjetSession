import { Link, createFileRoute } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { object, string, number, boolean } from "yup";
import Input from "../../components/form/input";
import { addMenuItem } from "../../api/menuItems";

export const Route = createFileRoute("/menuItem/create")({
  component: Create,

  staleTime: 0,
});

function Create() {
  let [name, setName] = useState("");
  let [description, setDescription] = useState("");
  let [price, setPrice] = useState("");
  let [available, setAvailable] = useState(false);
  const [errors, setErrors] = useState({});

  useEffect(() => {
    setErrors(errors);
  }, [errors]);

  const validationSchema = object().shape({
    name: string().required(),
    description: string().required(),
    price: number().required(),
    available: boolean().required(),
  });

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
      await addMenuItem(formData);
    } catch (validationErrors: any) {
      const formattedErrors: Array<any> = [];
      validationErrors.inner.forEach((error: any) => {
        formattedErrors[error.path] = error.message;
      });
      setErrors(formattedErrors);
    }
  };

  const handleToggleChange = (e: any) => {
    setAvailable(e.target.checked);
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-6 max-w-md mx-auto">
      <h1 className="text-center text-3xl mb-4">Ajouter un plat</h1>
      <form
        method="post"
        action={import.meta.env.BASE_URL + "/menu"}
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
          <button type="submit" className="btn btn-success mt-4 text-white">
            Soummettre
          </button>
        </div>
      </form>
    </div>
  );
}
