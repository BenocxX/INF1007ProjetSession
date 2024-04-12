import { createFileRoute, useParams } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { fetchMenuItemById, updateMenuItem } from "../../../api/menuItems";
import Input from "../../../components/form/input";
import { object, string, number } from "yup";

export const Route = createFileRoute("/menuItem/$menuItemId/edit")({
  component: Edit,
  staleTime: 0,
});

function Edit() {
  const { menuId } = useParams({ strict: false });
  let [name, setName] = useState("");
  let [description, setDescription] = useState("");
  let [price, setPrice] = useState("");
  const [errors, setErrors] = useState({});

  useEffect(() => {
    const id = parseInt(menuId, 10);
    fetchItem(id);
  }, [menuId]);

  const validationSchema = object().shape({
    name: string().required(),
    description: string().required(),
    price: number().required(),
  });

  const fetchItem = async (id: number) => {
    const data = await fetchMenuItemById(id);
    setName(data.name);
    setDescription(data.description);
    setPrice(data.price);
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      name: name,
      description: description,
      price: price,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
    } catch (validationErrors: any) {
      const formattedErrors: Array<any> = [];
      validationErrors.inner.forEach((error: any) => {
        formattedErrors[error.path] = error.message;
      });
      setErrors(formattedErrors);
    }

    if (errors.length == 0) {
      await updateMenuItem(parseInt(menuId, 10), formData);
    }
  };

  return (
    <div>
      <h1 className="text-center text-3xl">Ajouter un plat</h1>
      <form
        method="put"
        action={import.meta.env.BASE_URL + "/menu/" + menuId}
        onSubmit={handleSubmit}
      >
        <Input
          name="name"
          placeholder="Nom du plat"
          value={name}
          onChange={setName}
          errors={errors}
        />
        <Input
          name="description"
          placeholder="Description"
          value={description}
          onChange={setDescription}
          errors={errors}
        />
        <Input
          name="price"
          placeholder="Prix"
          type="number"
          value={price}
          onChange={setPrice}
          errors={errors}
        />

        <button type="submit" className="btn btn-primary">
          Soummettre
        </button>
      </form>
    </div>
  );
}
