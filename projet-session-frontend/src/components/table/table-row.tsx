import React from "react";

type TableRowProps = {
  data: Array<any>;
  columns: Array<string>;
};

const TableRow: React.FC<TableRowProps> = ({ data, columns, deleteHandle }) => {
  return (
    <div>
      <div className="overflow-x-auto">
        <table className="table">
          <thead>
            <tr>
              {columns.map((columnName, index) => (
                <th key={index}>{columnName}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {data.map((item, rowIndex) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.description}</td>
                <td>{item.price}</td>
                <th>
                  <button
                    onClick={() => deleteHandle(item.id)}
                    className="btn btn-warinf btn-xs"
                  >
                    Delete
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
