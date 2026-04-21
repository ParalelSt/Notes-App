import { useState } from "react";
import { useNavigate } from "react-router-dom";

const Auth = () => {
  const URL = "http://localhost:5218";

  const [authMode, setAuthMode] = useState<"login" | "register">("login");
  const [showPassword, setShowPassword] = useState(false);

  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [identifier, setIdentifier] = useState("");
  const [email, setEmail] = useState("");
  const [userName, setUserName] = useState("");

  const [error, setError] = useState("");

  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const res = await fetch(`${URL}/api/User/log-in`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          identifier: identifier.trim(),
          password: password,
        }),
      });

      if (!res.ok) {
        const errorData = await res.json();
        throw new Error(errorData.error);
      }

      const data = await res.json();
      localStorage.setItem("token", data.token);
      navigate("/");
    } catch (error) {
      console.error({ error: error });
      if (error instanceof Error) {
        setError(error.message);
        setTimeout(() => {
          setError("");
        }, 2000);
      } else {
        setError("Something went wrong");
      }
    }
  };

  const handleRegister = async () => {
    try {
      const res = await fetch(`${URL}/api/User/register`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          email: email,
          username: userName,
          password: password,
          confirmPassword: confirmPassword,
        }),
      });

      if (!res.ok) {
        const errorData = await res.json();
        throw new Error(errorData.error);
      }

      const data = await res.json();
      setAuthMode("login");
      console.log(data.email && data.username);
    } catch (error) {
      console.error({ error: error });
      if (error instanceof Error) {
        setError(error.message);
        setTimeout(() => {
          setError("");
        }, 2000);
      } else {
        setError("Something went wrong");
      }
    }
  };

  return (
    <>
      {authMode === "login" && (
        <div
          className={`flex flex-col max-w-80 w-full h-100 p-4 rounded-xl shadow-sm border border-transparent bg-surface`}
        >
          <div className="absolute top-1 text-red-600">{error}</div>
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
          <button onClick={() => setAuthMode("register")}>
            Go to Register
          </button>
          <button onClick={handleLogin}>Log In</button>
        </div>
      )}

      {authMode === "register" && (
        <div
          className={`flex flex-col max-w-80 w-full h-100 p-4 rounded-xl shadow-sm border border-transparent bg-surface`}
        >
          <div className="absolute top-1 text-red-600">{error}</div>
          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <input
            type="text"
            placeholder="Username"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
          />
          <input
            type={showPassword ? "text" : "password"}
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <input
            type={showPassword ? "text" : "password"}
            placeholder="Password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
          <button onClick={() => setShowPassword(!showPassword)}>Toggle</button>
          <button onClick={() => setAuthMode("login")}>Go to Login</button>
          <button onClick={handleRegister}>Register</button>
        </div>
      )}
    </>
  );
};

export default Auth;
