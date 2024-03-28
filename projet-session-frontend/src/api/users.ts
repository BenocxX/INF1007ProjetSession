export type User = {
  name: number;
};

export async function fetchUsers(): Promise<User[]> {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/users`);
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}
