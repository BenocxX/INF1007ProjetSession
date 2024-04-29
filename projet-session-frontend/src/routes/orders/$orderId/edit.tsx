import {
  createFileRoute,
  redirect,
  useNavigate,
  useParams,
} from "@tanstack/react-router";
import { hasRole } from "../../../api/auth";
import { useEffect, useState } from "react";
import { fetchOrder, updateOrder } from "../../../api/order";
import { number, object } from "yup";
import FlashMessage, {
  FlashMessageProps,
} from "../../../components/flash/flash";

export const Route = createFileRoute("/orders/$orderId/edit")({
  beforeLoad: async ({ location }) => {
    if (!hasRole("Admin")) {
      throw redirect({
        to: "/auth/login",
        search: {
          redirect: location.href,
        },
      });
    }
  },
  component: Edit,
});

function Edit() {
  const navigate = useNavigate({ from: "/order/" });
  const { orderId } = useParams({ strict: false });
  const [paymentMethod, setPaymentMethod] = useState(0);
  const [status, setStatus] = useState(0);
  const [tps, setTps] = useState(0);
  const [tvq, setTvq] = useState(0);
  const [subTotal, setSubTotal] = useState(0);
  const [clientBillingInfoId, setClientBillingInfoId] = useState(0);
  const [total, setTotal] = useState(0);
  const [errors, setErrors] = useState({});
  const [flashMessage, setFlashMessage] = useState<FlashMessageProps>();

  const urlParams = new URLSearchParams(window.location.search);
  const redirectParam = urlParams.get("redirect");

  useEffect(() => {
    const id = parseInt(orderId, 10);
    fetchItem(id);
  }, [orderId]);

  async function fetchItem(id: number) {
    const data = await fetchOrder(id);
    setClientBillingInfoId(data.clientBillingInfoId);
    setPaymentMethod(data.paymentMethod);
    setStatus(data.status);
    setTps(data.tps);
    setTvq(data.tvq);
    setSubTotal(data.subTotal);
    setTotal(data.total);
  }

  const handleChange = (event: any) => {
    setPaymentMethod(parseInt(event.target.value));
  };

  const handleChangeStatus = (event: any) => {
    setStatus(parseInt(event.target.value));
  };

  const validationSchema = object().shape({
    paymentMethod: number().min(0).max(2).required("Paiement est requis"),
    status: number().min(0).max(5).required("Status est requis"),
  });

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    const formData = {
      paymentMethod: paymentMethod,
      status: status,
      tps: tps,
      tvq: tvq,
      subTotal: subTotal,
      total: total,
      clientBillingInfoId: clientBillingInfoId,
    };

    try {
      await validationSchema.validate(formData, { abortEarly: false });
      const response = await updateOrder(orderId, formData);
      setFlashMessage({
        type: "success",
        message: "Commande modifié avec succès.",
      });
      setTimeout(() => {
        navigate({ to: redirectParam || "/orders" });
      }, 2000);
    } catch (validationErrors: any) {
      const formattedErrors: Array<any> = [];
      validationErrors.inner.forEach((error: any) => {
        formattedErrors[error.path] = error.message;
      });
      setErrors(formattedErrors);
      setFlashMessage({
        type: "error",
        message: "Une erreur est survenue.",
      });
    }
  };

  return (
    <div>
      <div>
        <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
          <FlashMessage
            type={flashMessage?.type}
            message={flashMessage?.message}
          />

          <div className="sm:mx-auto sm:w-full sm:max-w-sm">
            <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
              État de la commande
            </h2>
          </div>
          <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
            <form className="space-y-6" onSubmit={handleSubmit}>
              <div className="mb-4">
                <label>Méthode de paiement :</label>
                <select
                  id="paymentMethod"
                  value={paymentMethod}
                  onChange={handleChange}
                  className="select select-bordered w-full max-w-xs mt-5"
                >
                  <option value={0}>Carte de crédit</option>
                  <option value={1}>Carte de débit</option>
                  <option value={2}>Cash</option>
                </select>
              </div>

              <div className="mb-4">
                <label>Status de la commande :</label>
                <select
                  id="paymentMethod"
                  value={status}
                  onChange={handleChangeStatus}
                  className="select select-bordered w-full max-w-xs mt-5"
                >
                  <option value={0}>En attente</option>
                  <option value={1}>En preparation</option>
                  <option value={2}>Cueillette</option>
                  <option value={3}>En livraison</option>
                  <option value={4}>Payé</option>
                  <option value={5}>Archivé</option>
                </select>
              </div>
              <button
                className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                onClick={handleSubmit}
              >
                Soumettre
              </button>
            </form>
            <div className="sm:mx-auto sm:w-full sm:max-w-sm">
              <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
                Information de facturation
              </h2>
            </div>
            <div className="max-w-lg mx-auto mt-8 p-8 bg-white shadow-md rounded-lg">
              <h2 className="text-2xl font-bold mb-4">Facture</h2>
              <div className="flex justify-between mb-4">
                <h3 className="text-lg">TPS :</h3>
                <h3 className="text-lg">{`$${(tps * subTotal).toFixed(2)}`}</h3>
              </div>
              <div className="flex justify-between mb-4">
                <h3 className="text-lg">TVQ :</h3>
                <h3 className="text-lg">{`$${(tvq * subTotal).toFixed(2)}`}</h3>
              </div>
              <div className="flex justify-between mb-4">
                <h3 className="text-lg">Sous-Total :</h3>
                <h3 className="text-lg">{`$${subTotal.toFixed(2)}`}</h3>
              </div>
              <div className="flex justify-between mb-4">
                <h3 className="text-lg">Total :</h3>
                <h3 className="text-lg">{`$${total.toFixed(2)}`}</h3>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
