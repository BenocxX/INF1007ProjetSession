import { createFileRoute } from "@tanstack/react-router";
import {
  OrderResponse,
  fetchOrderByUserId,
  getStatusText,
} from "../../../../api/order";

export const Route = createFileRoute("/orders/user/$userId/")({
  component: Index,
  loader: async ({ params }) => {
    return fetchOrderByUserId(+params.userId);
  },
  staleTime: 0,
});

function Index() {
  const orders = Route.useLoaderData();

  return (
    <div>
      <div>
        <h1 className="text-center text-3xl">Liste des commandes</h1>
        {orders ? (
          <div className="overflow-x-auto">
            <table className="table">
              <thead>
                <tr>
                  <th>Status</th>
                  <th>Sous-total</th>
                  <th>Total</th>
                </tr>
              </thead>
              <tbody>
                {orders.map((order: OrderResponse) => (
                  <tr key={order.orderId}>
                    <td>
                      <div>{getStatusText(order.status)}</div>
                    </td>
                    <td>
                      <div>{order.subTotal}</div>
                    </td>
                    <th>
                      <div>{order.total}</div>
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
