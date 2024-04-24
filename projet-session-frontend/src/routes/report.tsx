import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/report")({
  component: () => <div>Je serais la page pour consulter les rapports !</div>,
});
