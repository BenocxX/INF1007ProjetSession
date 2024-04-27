import { fetchWithToken } from "./api";

export type MenuItem = {
  menuItemId: number;
  name: string;
  description: string;
  price: number;
  available: boolean;
};

export async function fetchMenuItem(): Promise<MenuItem[]> {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/menuitem`);
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}

export async function fetchMenuItemById(id: number) {
  const response = await fetch(
    `${import.meta.env.VITE_API_URL}/menuitem/${id}`
  );
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}

export async function addMenuItem(formData: any) {
  return await fetchWithToken(`/menuitem`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(formData),
  });
}

export async function updateMenuItem(id: number, formData: any) {
  return await fetchWithToken(`/menuitem/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(formData),
  });
}

export async function deleteMenuItem(id: number) {
  return await fetchWithToken(`/menuitem/${id}`, {
    method: "DELETE",
  });
}
