import { createFileRoute } from "@tanstack/react-router";
import { fetchUsers } from "../api/users";

export const Route = createFileRoute("/users")({
  component: UserPage,
  loader: fetchUsers,

  // Consider the route's data fresh for 10 seconds
  staleTime: 0,
});

function UserPage() {
  const users = Route.useLoaderData();
  console.log(users);

  return (
    <div className="p-2">
      <h1 className="text-center text-3xl mb-4">Liste des utilisateurs</h1>
      {users === null && <p>Error loading users</p>}
      {users && users.length === 0 && <p>Loading...</p>}
      {users && users.length > 0 && (
        <table className="table table-compact">
          <thead>
            <tr>
              <th>Prénom</th>
              <th>Nom</th>
              <th>Courriel</th>
            </tr>
          </thead>
          <tbody>
            {users.map((user) => (
              <tr>
                <td>{user.firstname}</td>
                <td>{user.lastname}</td>
                <td>{user.email}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
