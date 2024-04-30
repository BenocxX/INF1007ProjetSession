import { Link, createFileRoute } from "@tanstack/react-router";
import {
  OrderResponse,
  deleteOrder,
  fetchOrders,
  getStatusText,
} from "../../api/order";
import { hasRole } from "../../api/auth";
import { useState } from "react";
import FlashMessage, { FlashMessageProps } from "../../components/flash/flash";

export const Route = createFileRoute("/orders/")({
  component: Index,
  loader: async () => {
    return fetchOrders();
  },
  staleTime: 0,
});

function Index() {
  const orders = Route.useLoaderData();
  const [flashMessage, setFlashMessage] = useState<FlashMessageProps>();

  const deleteHandle = async (id: number) => {
    const response = await deleteOrder(id);
    if (response.ok) {
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

  return (
    <div>
      <div>
        <h1 className="text-center text-3xl">Liste des commandes</h1>
        <FlashMessage
          type={flashMessage?.type}
          message={flashMessage?.message}
        />

        {orders ? (
          <div className="overflow-x-auto">
            <table className="table">
              <thead>
                <tr>
                  <th>Status</th>
                  <th>Sous-total</th>
                  <th>Total</th>
                  {hasRole("Admin") && <th>Action</th>}
                </tr>
              </thead>
              <tbody>
                {orders.map((order: OrderResponse) => (
                  <tr key={order.orderId}>
                    <td>
                      <div>{getStatusText(order.status)}</div>
                    </td>
                    <td>
                      <div>{order.subTotal.toFixed(2) + " $"}</div>
                    </td>
                    <th>
                      <div>{order.total.toFixed(2) + " $"}</div>
                    </th>
                    {hasRole("Admin") && (
                      <td>
                        <Link
                          to="/orders/$orderId/edit"
                          params={{ orderId: order.orderId.toString() }}
                          className="btn btn-info text-white btn-xs mx-2"
                        >
                          Modifier
                        </Link>
                        <button
                          type="button"
                          onClick={() => deleteHandle(order.orderId)}
                          className="btn btn-error text-white btn-xs"
                        >
                          Supprimer
                        </button>
                      </td>
                    )}
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
