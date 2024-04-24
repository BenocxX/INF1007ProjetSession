import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
  component: Index,
});

function Index() {
  return (
    <div>
      <h1 className="text-center text-3xl mb-4">
        Bienvenue Chez pizza house !
      </h1>
    </div>
  );
}
