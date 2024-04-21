import { Link, createFileRoute, redirect } from "@tanstack/react-router";
import isAuthenticated from "../../api/auth";
import TableRestaurant from "../../components/table/table-restaurant";
import { useEffect, useState } from "react";
import { Restaurant, deletRestaurant } from "../../api/restaurant";

export const Route = createFileRoute("/restaurant/")({
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
  component: Index,

  staleTime: 0,
});

function Index() {
  const [data, setData] = useState<Restaurant[]>([]);

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
      alert("Delete successful");
    } else {
      console.error("Delete failed");
    }
  };

  const columns = ["Numéro", "Nom", "Adresse", "Action"];

  return (
    <div>
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
