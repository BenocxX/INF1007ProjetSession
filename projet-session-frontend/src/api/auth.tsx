import { User } from "./users";

export async function login(formData: any) {
  await fetch(`${import.meta.env.VITE_API_URL}/login`, {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(formData),
  })
    .then((r) => r.json())
    .then((res) => {
      console.log(res);
    });
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
