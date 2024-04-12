import { createFileRoute } from "@tanstack/react-router";
import { SetStateAction, useEffect, useState } from "react";
import { object, string, number } from "yup";
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
  const [errors, setErrors] = useState({});

  useEffect(() => {
    setErrors(errors);
  }, [errors]);

  const validationSchema = object().shape({
    name: string().required(),
    description: string().required(),
    price: number().required(),
  });

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      name: name,
      description: description,
      price: price,
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

  return (
    <div>
      <h1 className="text-center text-3xl">Ajouter un plat</h1>
      <form
        method="post"
        action={import.meta.env.BASE_URL + "/menu"}
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
