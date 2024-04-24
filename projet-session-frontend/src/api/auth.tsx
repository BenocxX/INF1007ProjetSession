import Cookies from "js-cookie";
import { jwtDecode } from "jwt-decode";

export default function isAuthenticated() {
  let token = Cookies.get("jwtToken");

  if (!token) {
    return false;
  }
  return true;
}

export const hasRole = (expectedRole: string): boolean => {
  let token = Cookies.get("jwtToken");

  if (!token) {
    return false;
  }

  try {
    const decodedToken = jwtDecode(token);
    const role = decodedToken.role;

    return role === expectedRole;
  } catch (error) {
    console.error("Error decoding JWT token:", error);
    return false;
  }
};

export async function login(formData: any) {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/login`, {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(formData),
  });

  const data = await response.json();
  setCookie(data);
}

export async function register(formData: any) {
  await fetch(`${import.meta.env.VITE_API_URL}/register`, {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(formData),
  })
    .then((r) => r.json())
    .then((res) => {
      if (res) {
        alert("New user is Created Successfully");
      }
    });
}

function setCookie(data: any) {
  Cookies.set("jwtToken", data.token, { expires: 1 });
}
