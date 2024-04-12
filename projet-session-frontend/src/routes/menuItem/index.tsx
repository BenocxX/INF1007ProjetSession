import React, { useEffect, useState } from "react";
import { createFileRoute } from "@tanstack/react-router";
import TableRow from "../../components/table/table-row";
import { Link } from "@tanstack/react-router";
import { deleteMenuItem } from "../../api/menuItems";

export const Route = createFileRoute("/menuItem/")({
  component: Index,

  staleTime: 0,
});

function Index() {
  const [data, setData] = useState<any>(null);

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/menu`)
      .then((response) => response.json())
      .then((json) => setData(json))
      .catch((error) => console.log(error));
  }, []);

  const deleteMenuItem = async (id: number) => {
    const response = await deleteMenuItem(id);
    if (response.ok) {
      alert("Delete successful");
      setData((data) => data.filter((item) => item.id !== id));
    } else {
      console.error("Delete failed");
    }
  };

  const columns = ["Id", "Nom", "Description", "Prix", "Action"];

  return (
    <div>
      <h1 className="text-center text-3xl">Liste des plats</h1>
      <div className="flex justify-end">
        <Link className="btn btn-primary justify-end" to="/menu/create">
          Ajouter
        </Link>
      </div>
      {data ? (
        <TableRow data={data} columns={columns} deleteHandle={deleteMenuItem} />
      ) : (
        <div>Loading...</div>
      )}
    </div>
  );
}
