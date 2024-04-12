import React from "react";

type InputProps = {
  name: string;
  placeholder?: string;
  type?: string;
  value: string | number;
  onChange: (value: any) => void;
  errors: Record<string, string>;
};

const Input: React.FC<InputProps> = ({
  name,
  placeholder,
  type = "text",
  value,
  onChange,
  errors,
}) => {
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    onChange(e.target.value);
  };

  return (
    <label className="form-control w-full max-w-xs">
      <input
        type={type}
        name={name}
        value={value}
        onChange={handleChange}
        placeholder={placeholder}
        className={`input input-bordered w-full max-w-xs ${errors[name] ? "input-error" : ""}`}
      />
      {errors[name] ? (
        <div className="label">
          <span className="label-text-alt text-red-500">{errors[name]}</span>
        </div>
      ) : null}
    </label>
  );
};

export default Input;
