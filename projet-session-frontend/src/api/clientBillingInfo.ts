import { fetchWithToken } from "./api";

export type ClientBillingInfoResponse = {
  clientBillingInfoId: number;
  address: string;
  userId: number;
};

export type ClientBillingInfoRequest = {
  address: string;
  cardName: string;
  cardNumber: string;
  expiryDate: string;
  cvv: string;
  userId: number;
};

export async function getClientBillingInfoByUserId(
  userId: number
): Promise<ClientBillingInfoResponse | undefined> {
  const response = await fetchWithToken(`/clientbillinginfo/user/${userId}`);

  if (response.status === 404) return undefined;

  return response.json();
}

export async function createClientBillingInfo(
  billingInfo: ClientBillingInfoRequest
): Promise<ClientBillingInfoResponse> {
  const response = await fetchWithToken("/clientbillinginfo", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(billingInfo),
  });

  if (!response.ok) throw new Error("Failed to create client billing info");

  return response.json();
}
