import { useEffect } from "react";
import Swal from "sweetalert2";

export interface FlashMessageProps {
  type: "success" | "error" | undefined;
  message: string | undefined;
}

const FlashMessage = ({ type, message }: FlashMessageProps) => {
  useEffect(() => {
    if (message) {
      Swal.fire({
        icon: type === "success" ? "success" : "error",
        title: message,
        timer: 2000,
        showConfirmButton: false,
      });
    }
  }, [message, type]);

  return null;
};

export default FlashMessage;
