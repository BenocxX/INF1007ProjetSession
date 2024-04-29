import { fetchWithToken } from "./api";

export type User = {
  name: number;
};

export async function fetchUsers(): Promise<User[]> {
  const response = await fetchWithToken(`/user`);
  if (!response.ok) throw new Error("Failed to fetch posts");
  return response.json();
}
