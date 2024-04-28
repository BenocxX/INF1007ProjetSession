import {
  Link,
  createFileRoute,
  redirect,
  useNavigate,
} from "@tanstack/react-router";
import Input from "../../components/form/input";
import { useEffect, useState } from "react";
import { object, string } from "yup";
import isAuthenticated, { login } from "../../api/auth";

export const Route = createFileRoute("/auth/login")({
  component: Login,
  beforeLoad: async () => {
    if (isAuthenticated()) {
      throw redirect({ to: "/" });
    }
  },
});

function Login() {
  const navigate = useNavigate({ from: "/auth/login" });
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errors, setErrors] = useState({});

  useEffect(() => {
    setErrors(errors);
  }, [errors]);

  const validationSchema = object().shape({
    email: string().email("Doit être un email").required("L'email est requis"),
    password: string()
      .required("Le mot de passe est requis")
      .min(8, "Le mot de passe doit avoir au moins 8 caractères"),
  });

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      email: email,
      password: password,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
      await login(formData);
      location.replace("/");
      navigate({ to: "/" });
    } catch (validationErrors: any) {
      const formattedErrors: Array<any> = [];
      validationErrors.inner.forEach((error: any) => {
        formattedErrors[error.path] = error.message;
      });
      setErrors(formattedErrors);
    }
  };

  return (
    <div>
      <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
        <div className="sm:mx-auto sm:w-full sm:max-w-sm">
          <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
            Connexion au compte
          </h2>
        </div>

        <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
          <form
            className="space-y-6"
            method="post"
            action={import.meta.env.BASE_URL + "/login"}
            onSubmit={handleSubmit}
          >
            <div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Adresse courriel
              </label>
              <div className="mt-2">
                <Input
                  name="email"
                  placeholder="Email"
                  type="email"
                  value={email}
                  onChange={setEmail}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <div className="flex items-center justify-between">
                <label className="block text-sm font-medium leading-6 text-gray-900">
                  Mot de passe
                </label>
                <div className="text-sm">
                  <a
                    href="#"
                    className="font-semibold text-indigo-600 hover:text-indigo-500"
                  >
                    Mot de passe oublié?
                  </a>
                </div>
              </div>
              <div className="mt-2">
                <Input
                  name="password"
                  placeholder="Mot de passe"
                  type="password"
                  value={password}
                  onChange={setPassword}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <button
                type="submit"
                className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
              >
                Connexion
              </button>
            </div>
          </form>

          <p className="mt-10 text-center text-sm text-gray-500">
            Pas de compte?
            <Link
              to="/auth/register"
              className="font-semibold leading-6 text-indigo-600 hover:text-indigo-500"
            >
              {" "}
              Créez-en un maintenant
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
}
