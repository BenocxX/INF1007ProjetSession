import { Link, createFileRoute, redirect } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { object, string } from "yup";
import Input from "../../components/form/input";
import { addMenu } from "../../api/menu";
import TableRow from "../../components/table/table-row";
import { MenuItem, deleteMenuItem } from "../../api/menuItems";
import isAuthenticated from "../../api/auth";

export const Route = createFileRoute("/menu/create")({
  beforeLoad: async ({ location }) => {
    if (!isAuthenticated()) {
      throw redirect({
        to: "/auth/login",
        search: {
          redirect: location.href,
        },
      });
    }
  },
  component: Create,
});

function Create() {
  let [name, setName] = useState("");
  let [menuItems, setMenuItems] = useState<MenuItem[]>([]);
  const [selectedMenuItems, setSelectedMenuItems] = useState<MenuItem[]>([]);
  const [errors, setErrors] = useState({});

  useEffect(() => {
    // Refactor
    fetch(`${import.meta.env.VITE_API_URL}/menuitem`)
      .then((response) => response.json())
      .then((json) => setMenuItems(json))
      .catch((error) => console.log(error));

    setErrors(errors);
  }, [errors]);

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
      const menuResponse = await addMenu(formData);
      const response = await menuResponse.json();
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
    console.log(item);

    if (selectedMenuItems.includes(item)) {
      setSelectedMenuItems(selectedMenuItems.filter((id) => id !== item));
    } else {
      setSelectedMenuItems([...selectedMenuItems, item]);
    }
  };

  const columns = ["Nom", "Description", "Prix", "Action"];

  return (
    <div>
      <h1 className="text-center text-3xl">Ajouter un menu</h1>
      <form
        method="post"
        action={import.meta.env.BASE_URL + "/menu"}
        onSubmit={handleSubmit}
      >
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
            <button type="button" className="btn btn-success text-white">
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
            isEdit={false}
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
