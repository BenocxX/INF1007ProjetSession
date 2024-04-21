import { Link } from "@tanstack/react-router";
import React from "react";

type TableRestaurantProps = {
  data: Array<any>;
  columns: Array<string>;
  deleteHandle: (id: number) => void;
};

const TableRestaurant: React.FC<TableRestaurantProps> = ({
  data,
  columns,
  deleteHandle,
}) => {
  return (
    <div>
      <div className="overflow-x-auto">
        <table className="table table-pin-rows">
          <thead>
            <tr>
              {columns.map((columnName, index) => (
                <th key={index}>{columnName}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {data.map((item) => (
              <tr key={item.menuItemId}>
                <td>{item.restaurantId}</td>
                <td>{item.name}</td>
                <td>{item.address}</td>
                <th>
                  <Link
                    to="/restaurant/$restaurantId/edit"
                    params={{ restaurantId: item.restaurantId }}
                    className="btn btn-info text-white btn-xs mx-2"
                  >
                    Modifier
                  </Link>
                  <button
                    type="button"
                    onClick={() => deleteHandle(item.restaurantId)}
                    className="btn btn-error text-white btn-xs"
                  >
                    Supprimer
                  </button>
                </th>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default TableRestaurant;
