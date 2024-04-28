import { fetchWithToken } from "./api";
import { MenuItem } from "./menuItems";

export type Menu = {
  menuId: number;
  name: string;
  menuItems: MenuItem[];
};

export async function fetchMenu(): Promise<Menu[]> {
  const response = await fetchWithToken(`/menu`);

  if (!response.ok) throw new Error("Failed to fetch posts");

  return response.json();
}

export async function fetchMenuById(id: number) {
  const response = await fetchWithToken(`/menu/${id}`);

  if (!response.ok) throw new Error("Failed to fetch posts");

  return response.json() as unknown as Menu;
}

export async function fetchMenuByRestaurantId(id: number) {
  const response = await fetchWithToken(`/restaurant/${id}`);

  if (!response.ok) throw new Error("Failed to fetch");

  return response.json();
}

export async function addMenu(menuData: unknown) {
  return await fetchWithToken(`/menu`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(menuData),
  });
}

export async function updateMenu(id: number, formData: unknown) {
  return await fetchWithToken(`/menu/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(formData),
  });
}

export async function deleteMenu(id: number) {
  return await fetchWithToken(`/menu/${id}`, {
    method: "DELETE",
  });
}
