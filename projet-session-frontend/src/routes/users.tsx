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

  return (
    <div className="p-2">
      <h1 className="text-xl">Users</h1>
      {users === null && <p>Error loading users</p>}
      {users && users.length === 0 && <p>Loading...</p>}
      {users && users.length > 0 && (
        <table className="table table-compact">
          <thead>
            <tr>
              <th>Name</th>
            </tr>
          </thead>
          <tbody>
            {users.map((user) => (
              <tr key={user.name}>
                <td>{user.name}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
