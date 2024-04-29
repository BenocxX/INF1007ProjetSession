import {
  Link,
  createFileRoute,
  redirect,
  useNavigate,
  useParams,
} from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { fetchMenuItemById, updateMenuItem } from "../../../api/menuItems";
import Input from "../../../components/form/input";
import { object, string, number, boolean } from "yup";
import { hasRole } from "../../../api/auth";
import FlashMessage, {
  FlashMessageProps,
} from "../../../components/flash/flash";

export const Route = createFileRoute("/menuItem/$menuItemId/edit")({
  beforeLoad: async ({ location }) => {
    if (!hasRole("Admin")) {
      throw redirect({
        to: "/auth/login",
        search: {
          redirect: location.href,
        },
      });
    }
  },
  component: Edit,
  staleTime: 0,
});

function Edit() {
  const navigate = useNavigate({ from: "/menu/" });
  const { menuItemId } = useParams({ strict: false });
  let [id, setId] = useState(menuItemId);
  let [name, setName] = useState("");
  let [description, setDescription] = useState("");
  let [price, setPrice] = useState("");
  const [errors, setErrors] = useState({});
  const [flashMessage, setFlashMessage] = useState<FlashMessageProps>();

  const urlParams = new URLSearchParams(window.location.search);
  const redirectParam = urlParams.get("redirect");

  useEffect(() => {
    setId(parseInt(menuItemId, 10));

    fetchItem(id);
  }, [menuItemId]);

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
      const response = await updateMenuItem(id, formData);
      setFlashMessage({
        type: "success",
        message: "Menu Item modifié avec succès.",
      });
      navigate({ to: redirectParam || "/menu/" });
    } catch (validationErrors: any) {
      const formattedErrors: Array<any> = [];
      validationErrors.inner.forEach((error: any) => {
        formattedErrors[error.path] = error.message;
      });
      setErrors(formattedErrors);
      setFlashMessage({
        type: "error",
        message: "Une erreur est survenue.",
      });
    }

    if (errors.length == 0) {
      await updateMenuItem(parseInt(menuItemId, 10), formData);
    }
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-6 max-w-md mx-auto">
      <FlashMessage type={flashMessage?.type} message={flashMessage?.message} />

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
