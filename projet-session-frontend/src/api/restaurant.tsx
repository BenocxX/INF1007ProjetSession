import { fetchWithToken } from "./api";

export type Restaurant = {
  restaurantId: number;
  menuId: number;
  name: string;
  address: string;
};

export async function fetchRestaurant() {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/restaurant`);
  if (!response.ok) throw new Error("Failed to fetch restaurants");
  return response.json();
}

export async function fetchRestaurantById(id: number) {
  const response = await fetch(
    `${import.meta.env.VITE_API_URL}/restaurant/${id}`
  );
  if (!response.ok) throw new Error("Failed to fetch restaurants");
  return response.json();
}

export async function addRestaurant(restaurantData: any) {
  return await fetchWithToken(`/restaurant`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(restaurantData),
  });
}

export async function updateRestaurant(id: number, restaurantData: any) {
  return await fetchWithToken(`/restaurant/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(restaurantData),
  });
}

export async function deleteRestaurant(id: number) {
  return await fetchWithToken(`/restaurant/${id}`, {
    method: "DELETE",
  });
}
