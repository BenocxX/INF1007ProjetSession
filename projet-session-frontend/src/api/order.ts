import { fetchWithToken } from "./api";

export type OrderStatus = 0 | 1 | 2 | 3 | 4 | 5;
export type PaymentMethod = 0 | 1 | 2;

export type OrderResponse = {
  orderId: number;
  status: OrderStatus;
  paymentMethod: PaymentMethod;
  tps: number;
  tvq: number;
  subTotal: number;
  total: number;
};

export type CreateOrderRequest = {
  paymentMethod: PaymentMethod;
  subTotal: number;
  clientBillingInfoId: number;
};

export function getStatusText(status: OrderStatus): string {
  switch (status) {
    case 0:
      return "En attente";
    case 1:
      return "En préparation";
    case 2:
      return "Prêt";
    case 3:
      return "En livraison";
    case 4:
      return "Livrée";
    case 5:
      return "Annulée";
  }
}

export async function fetchOrders(): Promise<OrderResponse[]> {
  const response = await fetchWithToken(`/order`);

  if (!response.ok) throw new Error("Failed to fetch posts");

  return response.json();
}

export async function fetchOrder(orderId: number): Promise<OrderResponse> {
  const response = await fetchWithToken(`/order/${orderId}`);

  if (!response.ok) throw new Error("Failed to fetch order");

  return response.json();
}

export async function fetchOrderByUserId(
  userId: number
): Promise<OrderResponse[]> {
  const response = await fetchWithToken(`/order/user/${userId}`);

  if (!response.ok) throw new Error("Failed to fetch order");

  return response.json();
}

export async function createOrder(
  request: CreateOrderRequest
): Promise<OrderResponse> {
  const response = await fetchWithToken(`/order`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(request),
  });

  console.log(request);

  if (!response.ok) throw new Error("Failed to create order");

  return response.json();
}

export async function deleteOrder(orderId: number): Promise<void> {
  const response = await fetchWithToken(`/order/${orderId}`, {
    method: "DELETE",
  });

  if (!response.ok) throw new Error("Failed to delete order");
}
