import { Link, createFileRoute, redirect } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { object, ref, string } from "yup";
import { register } from "../../api/auth";
import Input from "../../components/form/input";

export const Route = createFileRoute("/auth/register")({
  component: SignUp,
});

function SignUp() {
  let [name, setName] = useState("");
  let [email, setEmail] = useState("");
  let [phone, setPhone] = useState("");
  let [password, setPassword] = useState("");
  let [confirmation, setConfirmation] = useState("");
  const [errors, setErrors] = useState({});

  useEffect(() => {
    setErrors(errors);
  }, [errors]);

  const validationSchema = object().shape({
    name: string().required("Le nom est requis"),
    email: string().email("Doit être un email").required("L'email est requis"),
    phone: string().required("Le téléphone est requis"),
    password: string()
      .required("Le mot de passe est requis")
      .min(8, "Le mot de passe doit avoir au moins 8 caractères"),
    confirmation: string()
      .required("La confirmation est requise")
      .oneOf([ref("password"), null], "Les mots de passe ne correspondent pas"),
  });

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      name: name,
      email: email,
      phone: phone,
      password: password,
      confirmation: confirmation,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
      await register(formData);
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
            Création du compte
          </h2>
        </div>

        <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
          <form
            className="space-y-6"
            method="post"
            action={import.meta.env.BASE_URL + "/register"}
            onSubmit={handleSubmit}
          >
            <div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Nom
              </label>
              <div className="mt-2">
                <Input
                  name="name"
                  placeholder="Nom"
                  type="text"
                  value={name}
                  onChange={setName}
                  errors={errors}
                />
              </div>
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
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Téléphone
              </label>
              <div className="mt-2">
                <Input
                  name="phone"
                  placeholder="Téléphone"
                  type="text"
                  value={phone}
                  onChange={setPhone}
                  errors={errors}
                />
              </div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Mot de passe
              </label>
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
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Confirmation
              </label>
              <div className="mt-2">
                <Input
                  name="password"
                  placeholder="Confirmation"
                  type="password"
                  value={confirmation}
                  onChange={setConfirmation}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <button
                type="submit"
                className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
              >
                Soummettre
              </button>
            </div>
          </form>

          <p className="mt-10 text-center text-sm text-gray-500">
            Déjà un compte?
            <Link
              to="/auth/login"
              className="font-semibold leading-6 text-indigo-600 hover:text-indigo-500"
            >
              {" "}
              Connectez-vous maintenant
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
}
