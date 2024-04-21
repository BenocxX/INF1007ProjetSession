import Cookies from "js-cookie";

export default function isAuthenticated() {
  return true;
}

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
