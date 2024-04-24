import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/order")({
  component: () => <div>Je serais l'historique des commandes!</div>,
});
