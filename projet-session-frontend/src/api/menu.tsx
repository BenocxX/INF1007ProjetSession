import { log } from "console";

export type Menu = {
  id: number;
  city: string;
};

export async function fetchMenu(): Promise<Menu[]> {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/menu`);
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}

export async function fetchMenuById(id: number) {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/menu/${id}`);
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}

export async function fetchMenuByRestaurantId(id: number) {
  const response = await fetch(
    `${import.meta.env.VITE_API_URL}/restaurant/${id}`
  );
  if (!response.ok) throw new Error("Failed to fetch");
  return response.json();
}

export async function addMenu(menuData: any) {
  return await fetch(`${import.meta.env.VITE_API_URL}/menu`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(menuData),
  });
}

export async function updateMenu(id: number, formData: any) {
  return await fetch(`${import.meta.env.VITE_API_URL}/menu/${id}`, {
    method: "PUT",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(formData),
  });
}

export async function deleteMenu(id: number) {
  console.log(id);

  return await fetch(`${import.meta.env.VITE_API_URL}/menu/${id}`, {
    method: "DELETE",
  });
}
