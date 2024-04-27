import { Link, createFileRoute, redirect } from "@tanstack/react-router";
import { hasRole } from "../../api/auth";
import TableRestaurant from "../../components/table/table-restaurant";
import { useEffect, useState } from "react";
import { Restaurant, deletRestaurant } from "../../api/restaurant";
import FlashMessage, { FlashMessageProps } from "../../components/flash/flash";

export const Route = createFileRoute("/restaurant/")({
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
  component: Index,

  staleTime: 0,
});

function Index() {
  const [data, setData] = useState<Restaurant[]>([]);
  const [flashMessage, setFlashMessage] = useState<FlashMessageProps>();

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/restaurant`)
      .then((response) => response.json())
      .then((json) => setData(json))
      .catch((error) => console.log(error));
  }, []);

  const handledelete = async (id: number) => {
    const response = await deletRestaurant(id);
    if (response.ok) {
      fetch(`${import.meta.env.VITE_API_URL}/restaurant`)
        .then((response) => response.json())
        .then((json) => setData(json))
        .catch((error) => console.log(error));
      setFlashMessage({
        type: "success",
        message: "Restaurant supprimer avec succès.",
      });
    } else {
      setFlashMessage({
        type: "error",
        message: "Une erreur est survenue.",
      });
    }
  };

  const columns = ["Numéro", "Nom", "Adresse", "Action"];

  return (
    <div>
      <FlashMessage type={flashMessage?.type} message={flashMessage?.message} />

      <h1 className="text-center text-3xl">Liste des restaurants</h1>
      <div className="flex justify-end">
        <Link
          className="btn btn-success justify-end text-white"
          to="/restaurant/create"
        >
          Ajouter
        </Link>
      </div>
      <TableRestaurant
        data={data}
        columns={columns}
        deleteHandle={handledelete}
      />
    </div>
  );
}
