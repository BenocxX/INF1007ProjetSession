import { createFileRoute, redirect, useNavigate } from "@tanstack/react-router";
import Input from "../../components/form/input";
import { useEffect, useState } from "react";
import { ValidationError, object, string } from "yup";
import isAuthenticated, { getUserId } from "../../api/auth";
import {
  createClientBillingInfo,
  getClientBillingInfoByUserId,
} from "../../api/clientBillingInfo";

export const Route = createFileRoute("/billing-info/")({
  component: Index,
  beforeLoad: async () => {
    if (!isAuthenticated()) {
      throw redirect({ to: "/auth/login", search: "?redirect=/billing-info/" });
    }

    const userId = getUserId();
    if (!userId) {
      throw new Error("User ID not found");
    }

    const billingInfo = await getClientBillingInfoByUserId(+userId);
    if (billingInfo) {
      throw redirect({ to: "/cart" });
    }
  },
});

function Index() {
  const navigate = useNavigate();
  const [address, setAddress] = useState("");
  const [cardName, setCardName] = useState("");
  const [cardNumber, setCardNumber] = useState("");
  const [expiryDate, setExpiryDate] = useState("");
  const [cvv, setCvv] = useState("");
  const [errors, setErrors] = useState({});

  // TODO: Try to remove this useEffect
  useEffect(() => {
    setErrors(errors);
  }, [errors]);

  const validationSchema = object().shape({
    address: string().required("L'adresse est requise"),
    cardName: string().required("Le nom sur la carte est requis"),
    cardNumber: string().required("Le numéro de la carte est requis"),
    expiryDate: string().required("La date d'expiration est requise"),
    cvv: string().required("Le CVV est requis"),
  });

  const handleSubmit = async (e: MouseEvent) => {
    e.preventDefault();

    const formData = {
      address,
      cardName,
      cardNumber,
      expiryDate,
      cvv,
    };

    const userId = getUserId();

    if (!userId) {
      console.error("User ID not found");
      return;
    }

    try {
      await validationSchema.validate(formData, { abortEarly: false });

      await createClientBillingInfo({
        ...formData,
        userId: +userId,
      });

      navigate({ to: "/cart" });
    } catch (error: unknown) {
      const formattedErrors: Array<unknown> = [];
      const validationErrors = error as ValidationError;
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
            Information de facturation
          </h2>
        </div>

        <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
          <form className="space-y-6" onSubmit={handleSubmit}>
            <div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Adresse
              </label>
              <div className="mt-2">
                <Input
                  name="address"
                  placeholder="Adresse"
                  type="text"
                  value={address}
                  onChange={setAddress}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Nom sur la carte
              </label>
              <div className="mt-2">
                <Input
                  name="cardName"
                  placeholder="cardName"
                  type="text"
                  value={cardName}
                  onChange={setCardName}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Numéro de la carte
              </label>
              <div className="mt-2">
                <Input
                  name="cardNumber"
                  placeholder="cardNumber"
                  type="number"
                  value={cardNumber}
                  onChange={setCardNumber}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                Date d'expiration
              </label>
              <div className="mt-2">
                <Input
                  name="expiryDate"
                  placeholder="expiryDate"
                  type="text"
                  value={expiryDate}
                  onChange={setExpiryDate}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <label className="block text-sm font-medium leading-6 text-gray-900">
                CVV
              </label>
              <div className="mt-2">
                <Input
                  name="cvv"
                  placeholder="cvv"
                  type="number"
                  value={cvv}
                  onChange={setCvv}
                  errors={errors}
                />
              </div>
            </div>

            <div>
              <button
                className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                onClick={handleSubmit}
              >
                Soumettre
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
