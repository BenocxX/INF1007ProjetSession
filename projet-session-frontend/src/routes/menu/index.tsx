import { Link, createFileRoute, redirect } from "@tanstack/react-router";
import { hasRole } from "../../api/auth";
import { useEffect, useState } from "react";
import { deleteMenu } from "../../api/menu";
import FlashMessage, { FlashMessageProps } from "../../components/flash/flash";

export const Route = createFileRoute("/menu/")({
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
  const [data, setData] = useState<any>(null);
  const [flashMessage, setFlashMessage] = useState<FlashMessageProps>();

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/menu`)
      .then((response) => response.json())
      .then((json) => setData(json))
      .catch((error) => console.log(error));
  }, []);

  const handleDelete = async (id: number) => {
    const response = await deleteMenu(id);
    if (response.ok) {
      fetch(`${import.meta.env.VITE_API_URL}/menu`)
        .then((response) => response.json())
        .then((json) => setData(json))
        .catch((error) => console.log(error));
      setFlashMessage({
        type: "success",
        message: "Menu supprimer avec succès.",
      });
    } else {
      setFlashMessage({
        type: "error",
        message: "Une erreur est survenue.",
      });
    }
  };

  return (
    <div>
      <div>
        <FlashMessage
          type={flashMessage?.type}
          message={flashMessage?.message}
        />

        <h1 className="text-center text-3xl">Liste des menus</h1>
        <div className="flex justify-end">
          <Link
            className="btn btn-success justify-end text-white"
            to="/menu/create"
          >
            Ajouter
          </Link>
        </div>
        {data ? (
          <div className="overflow-x-auto">
            <table className="table">
              <thead>
                <tr>
                  <th>Numero</th>
                  <th>Nom</th>
                  <th></th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {data.map((item: any) => (
                  <tr key={item.id}>
                    <td>
                      <div>{item.menuId} </div>
                    </td>
                    <td>
                      <div>{item.name} </div>
                    </td>
                    <td></td>

                    <th>
                      <Link
                        type="button"
                        className="btn btn-info text-white btn-xs"
                        to="/menu/$menuId/edit"
                        params={{ menuId: item.menuId }}
                      >
                        Modifier
                      </Link>
                      <button
                        type="button"
                        className="btn btn-error text-white btn-xs mx-4"
                        onClick={() => handleDelete(item.menuId)}
                      >
                        Supprimer
                      </button>
                    </th>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        ) : (
          <div>Loading...</div>
        )}
      </div>
    </div>
  );
}
