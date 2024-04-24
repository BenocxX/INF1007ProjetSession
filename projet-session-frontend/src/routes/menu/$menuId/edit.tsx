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
import TableRow from "../../../components/table/table-row";
import Input from "../../../components/form/input";
import { object, string } from "yup";

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
  const [selectedMenuItems, setSelectedMenuItems] = useState<MenuItem[]>([]);
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
    console.log(data);

    setName(data.Name);
    data.MenuItems.forEach((item: any) => {
      setSelectedMenuItems((prevItems) => {
        const updatedItems = [...prevItems, item.MenuItem];
        return updatedItems;
      });
    });
  };

  const validationSchema = object().shape({
    name: string().required("Nom est requis"),
  });

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      name: name,
      menuItems: selectedMenuItems,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
      const menuResponse = await updateMenu(menuId, formData);
      console.log(menuResponse);

      // redirect
    } catch (validationErrors: any) {
      const formattedErrors: Array<any> = [];
      validationErrors.inner.forEach((error: any) => {
        formattedErrors[error.path] = error.message;
      });
      setErrors(formattedErrors);
    }
  };

  const hanleDeleteMenuItem = async (id: number) => {
    const response = await deleteMenuItem(id);
    if (response.ok) {
      alert("Delete successful");
      setMenuItems((data) => data.filter((item) => item.menuItemId !== id));
    } else {
      console.error("Delete failed");
    }
  };

  const handleCheckboxClick = (item: MenuItem) => {
    if (selectedMenuItems.includes(item)) {
      setSelectedMenuItems(selectedMenuItems.filter((id) => id !== item));
    } else {
      setSelectedMenuItems([...selectedMenuItems, item]);
    }
  };

  const columns = ["Nom", "Description", "Prix", "Action"];

  return (
    <div>
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
          <TableRow
            data={menuItems}
            columns={columns}
            deleteHandle={hanleDeleteMenuItem}
            onCheckboxClick={handleCheckboxClick}
            selectedValue={selectedMenuItems}
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
