import { fetchWithToken } from "./api";

export type ClientBillingInfoResponse = {
  clientBillingInfoId: number;
  address: string;
  userId: number;
};

export async function getClientBillingInfoByUserId(
  userId: number
): Promise<ClientBillingInfoResponse> {
  const response = await fetchWithToken(`/clientbillinginfo/user/${userId}`);

  if (!response.ok) throw new Error("Failed to fetch client billing info");

  return response.json();
}
