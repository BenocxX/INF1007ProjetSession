import {
  Link,
  createFileRoute,
  redirect,
  useParams,
} from "@tanstack/react-router";
import { hasRole } from "../../../api/auth";
import { useEffect, useState } from "react";
import { fetchMenuById, updateMenu } from "../../../api/menu";
import {
  MenuItem,
  deleteMenuItem,
  fetchMenuItem,
} from "../../../api/menuItems";
import Input from "../../../components/form/input";
import { object, string } from "yup";
import TableMenuItem from "../../../components/table/table-menuItem";
import FlashMessage, {
  FlashMessageProps,
} from "../../../components/flash/flash";

export const Route = createFileRoute("/menu/$menuId/edit")({
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
  const { menuId } = useParams({ strict: false });
  let [name, setName] = useState("");
  let [menuItems, setMenuItems] = useState<MenuItem[]>([]);
  const [flashMessage, setFlashMessage] = useState<FlashMessageProps>();
  const [selectedMenuItemsId, setSelectedMenuItemsId] = useState<number[]>([]);
  const [errors, setErrors] = useState({});

  useEffect(() => {
    const id = parseInt(menuId, 10);
    fetchItem(id);
    fetchAllMenuItem();
  }, [menuId]);

  const fetchAllMenuItem = async () => {
    const data = await fetchMenuItem();
    setMenuItems(data);
  };

  const fetchItem = async (id: number) => {
    const data = await fetchMenuById(id);
    setName(data.name);

    data.menuItems.forEach((item: any) => {
      setSelectedMenuItemsId([...selectedMenuItemsId, item.menuItemId]);
    });
  };

  const validationSchema = object().shape({
    name: string().required("Nom est requis"),
  });

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      name: name,
      menuItemsId: selectedMenuItemsId,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
      const menuResponse = await updateMenu(menuId, formData);
      setFlashMessage({
        type: "success",
        message: "Menu modifié avec succès.",
      });
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

  const hanleDeleteMenuItem = async (id: number) => {
    const response = await deleteMenuItem(id);
    if (response.ok) {
      setFlashMessage({
        type: "success",
        message: "Menu Item supprimer avec succès.",
      });
      setMenuItems((data) => data.filter((item) => item.menuItemId !== id));
    } else {
      setFlashMessage({
        type: "error",
        message: "Une erreur est survenue.",
      });
    }
  };

  const handleCheckboxClick = (item: MenuItem) => {
    if (selectedMenuItemsId.includes(item.menuItemId)) {
      setSelectedMenuItemsId(
        selectedMenuItemsId.filter((id) => id !== item.menuItemId)
      );
    } else {
      setSelectedMenuItemsId([...selectedMenuItemsId, item.menuItemId]);
    }
  };

  const columns = ["Nom", "Description", "Prix", "Action"];

  return (
    <div>
      <FlashMessage type={flashMessage?.type} message={flashMessage?.message} />

      <h1 className="text-center text-3xl">Modifier un menu</h1>
      <form method="post" onSubmit={handleSubmit}>
        <h3 className="">Information générale:</h3>
        <div className="flex flex-col my-5">
          <Input
            name="name"
            placeholder="Nom"
            value={name}
            onChange={setName}
            errors={errors}
          />
        </div>
        <div className="flex justify-between">
          <h3>Liste des plats:</h3>
          <Link to="/menuItem/create">
            <button
              type="button"
              className="btn btn-success justify-end text-white"
            >
              Ajouter
            </button>
          </Link>
        </div>

        {menuItems ? (
          <TableMenuItem
            data={menuItems}
            columns={columns}
            deleteHandle={hanleDeleteMenuItem}
            onCheckboxClick={handleCheckboxClick}
            selectedValue={selectedMenuItemsId}
            isEdit={true}
          />
        ) : (
          <div>Loading...</div>
        )}
        <div className="flex justify-end">
          <Link to="/menu" type="button" className="btn btn-light m-4">
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
