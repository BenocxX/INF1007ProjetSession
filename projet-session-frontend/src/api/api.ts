import Cookies from "js-cookie";

export function fetchWithToken(url: string, options: RequestInit = {}) {
  return fetch(`${import.meta.env.VITE_API_URL}${url}`, {
    ...options,
    headers: {
      ...options.headers,
      Authorization: `Bearer ${Cookies.get("jwtToken")}`,
    },
  });
}
