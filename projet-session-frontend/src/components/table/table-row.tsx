import { Link } from "@tanstack/react-router";
import React from "react";

type TableRowProps = {
  data: Array<any>;
  columns: Array<string>;
  isEdit: boolean;
  deleteHandle: (id: number) => void;
  onCheckboxClick: (menuItem: any) => void;
  selectedValue: Array<any>;
};

const TableRow: React.FC<TableRowProps> = ({
  data,
  columns,
  isEdit,
  deleteHandle,
  onCheckboxClick,
  selectedValue,
}) => {
  const toCapitalCaseKeys = (obj: any) => {
    return Object.fromEntries(
      Object.entries(obj).map(([key, value]) => {
        const capitalCaseKey = key.charAt(0).toUpperCase() + key.slice(1);
        return [capitalCaseKey, value];
      })
    );
  };

  const isItemSelected = (itemId: number) => {
    const transformedData = selectedValue.map(toCapitalCaseKeys);
    return transformedData.some((item) => item.MenuItemId === itemId);
  };

  return (
    <div>
      <div className="overflow-x-auto">
        <table className="table table-pin-rows">
          <thead>
            <tr>
              <th></th>
              {columns.map((columnName, index) => (
                <th key={index}>{columnName}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {data.map((item, rowIndex) => (
              <tr key={item.menuItemId}>
                <th>
                  <label>
                    <input
                      type="checkbox"
                      className="checkbox"
                      onChange={() => onCheckboxClick(item)}
                      checked={
                        isEdit
                          ? selectedValue
                            ? isItemSelected(item.menuItemId)
                            : false
                          : undefined
                      }
                    />
                  </label>
                </th>
                <td>
                  <div className="flex items-center gap-3">
                    <div className="avatar">
                      <div className="mask mask-squircle w-12 h-12">
                        <img
                          src="/tailwind-css-component-profile-2@56w.png"
                          alt="Avatar Tailwind CSS Component"
                        />
                      </div>
                    </div>
                    <div>{item.name} </div>
                  </div>
                </td>
                <td>{item.description}</td>
                <td>{item.price}</td>
                <th>
                  <Link
                    to="/menuItem/$menuItemId/edit"
                    params={{ menuItemId: item.menuItemId }}
                    className="btn btn-info text-white btn-xs mx-2"
                  >
                    Modifier
                  </Link>
                  <button
                    type="button"
                    onClick={() => deleteHandle(item.menuItemId)}
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

export default TableRow;
