import {
  Link,
  createFileRoute,
  redirect,
  useNavigate,
  useParams,
} from "@tanstack/react-router";
import { hasRole } from "../../../api/auth";
import { useEffect, useState } from "react";
import { object, string } from "yup";
import Input from "../../../components/form/input";
import { fetchRestaurantById, updateRestaurant } from "../../../api/restaurant";
import FlashMessage, {
  FlashMessageProps,
} from "../../../components/flash/flash";

export const Route = createFileRoute("/restaurant/$restaurantId/edit")({
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
});

function Edit() {
  const navigate = useNavigate({ from: "/restaurant/" });
  const { restaurantId } = useParams({ strict: false });
  const [name, setName] = useState("");
  const [address, setAddress] = useState("");
  let [menuId, setMenuId] = useState("");
  let [menu, setMenu] = useState<any>([]);
  const [errors, setErrors] = useState({});
  const [flashMessage, setFlashMessage] = useState<FlashMessageProps>();

  const urlParams = new URLSearchParams(window.location.search);
  const redirectParam = urlParams.get("redirect");

  useEffect(() => {
    const id = parseInt(restaurantId, 10);
    fetchItem(id);

    // Refactor
    fetch(`${import.meta.env.VITE_API_URL}/menu`)
      .then((response) => response.json())
      .then((json) => setMenu(json))
      .catch((error) => console.log(error));

    setErrors(errors);
  }, [errors]);

  const fetchItem = async (id: number) => {
    const data = await fetchRestaurantById(id);
    setName(data.name);
    setAddress(data.address);
    setMenuId(data.menuId);
  };

  const validationSchema = object().shape({
    name: string().required("Nom est requis"),
    address: string().required("Adresse est requis"),
    menuId: string()
      .matches(/^[0-9]+$/, "Must be a number")
      .required("Restaurant est requis"),
  });

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      name: name,
      address: address,
      menuId: menuId,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
      const response = await updateRestaurant(restaurantId, formData);
      setFlashMessage({
        type: "success",
        message: "Restaurant modifié avec succès.",
      });
      setTimeout(() => {
        navigate({ to: redirectParam || "/restaurant/" });
      }, 2000);
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
  };

  const handleRestaurantChange = (event: any) => {
    setMenuId(event.target.value);
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-6 max-w-md mx-auto">
      <FlashMessage type={flashMessage?.type} message={flashMessage?.message} />

      <h1 className="text-center text-3xl mb-4">Modifier un restaurant</h1>
      <form method="post" onSubmit={handleSubmit}>
        <div className="flex flex-col my-5">
          <div className="mb-4">
            <Input
              name="name"
              placeholder="Nom"
              value={name}
              onChange={setName}
              errors={errors}
            />
          </div>

          <Input
            name="address"
            placeholder="Adresse"
            value={address}
            onChange={setAddress}
            errors={errors}
          />
          <select
            className="select select-bordered w-full max-w-xs mt-5"
            value={menuId}
            onChange={handleRestaurantChange}
          >
            <option value="">Choisir un menu</option>
            {menu.map((menu: any) => (
              <option key={menu.menuId} value={menu.menuId}>
                {menu.name}
              </option>
            ))}
          </select>
        </div>

        <div className="flex justify-end">
          <Link to="/restaurant" type="button" className="btn btn-light m-4">
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
