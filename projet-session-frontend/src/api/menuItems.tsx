export type MenuItem = {
  id: number;
  name: string;
  description: string;
  price: number;
};

export async function fetchMenuItem(): Promise<MenuItem[]> {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/menu`);
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}

export async function fetchMenuItemById(id: number) {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/menu/${id}`);
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}

export async function addMenuItem(formData: any) {
  await fetch(`${import.meta.env.VITE_API_URL}/menu`, {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(formData),
  })
    .then((r) => r.json())
    .then((res) => {
      if (res) {
        alert("New menu is Created Successfully");
      }
    });
}

export async function updateMenuItem(id: number, formData: any) {
  await fetch(`${import.meta.env.VITE_API_URL}/menu/${id}`, {
    method: "PUT",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(formData),
  })
    .then((r) => r.json())
    .then((res) => {
      if (res) {
        alert("New menu is Created Successfully");
      }
    });
}

export async function deleteMenuItem(id: number) {
  return await fetch(`${import.meta.env.VITE_API_URL}/menu/${id}`, {
    method: "DELETE",
  });
}
