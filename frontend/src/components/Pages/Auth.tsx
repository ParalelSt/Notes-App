import { useState } from "react";
import { useNavigate } from "react-router-dom";

const Auth = () => {
  const [showPassword, setShowPassword] = useState(false);
  const [password, setPassword] = useState("");
  const [identifier, setIdentifier] = useState("");

  const navigate = useNavigate();

  const handleLogin = async () => {
    const res = await fetch("http://localhost:5218/api/User/log-in", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        identifier: identifier.trim(),
        password: password,
      }),
    });

    const data = await res.json();
    localStorage.setItem("token", data.token);
    navigate("/");
  };

  return (
    <>
      <div
        className={`flex flex-col max-w-80 w-full h-100 p-4 rounded-xl shadow-sm border border-transparent bg-surface`}
      >
        <input
          type="text"
          placeholder="Email or Username"
          value={identifier}
          onChange={(e) => setIdentifier(e.target.value)}
        />
        <input
          type={showPassword ? "text" : "password"}
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button onClick={() => setShowPassword(!showPassword)}>Toggle</button>
        <button onClick={handleLogin}>Log In</button>
      </div>
    </>
  );
};

export default Auth;
