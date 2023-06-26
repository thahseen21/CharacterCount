import { Flip, ToastContainer, Zoom, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useState } from "react";
import "./App.css";

import CharacterResult from "./Components/CharacterResult";

type CharacterCount = {
    key: string;
    count: number;
};

function App() {
    const [characterCount, setCharacterCount] = useState<CharacterCount[]>([]);

    const [input, setInput] = useState("");

    const fetchCharacterCount = async () => {
        if (input.trim().length <= 0) {
            toast("Enter a valid sentence/word", { type: "warning" });
            setCharacterCount([]);
            return;
        }

        const baseURL = "https://localhost:7165/Home/GetCharacterCount";

        let options: RequestInit = {
            method: "post",
            headers: {
                "Access-Control-Allow-Origin": "*",
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                input: input,
            }),
        };

        try {
            let response = await fetch(baseURL, options);
            let result = await response.json();
            if (!response.ok) {
                toast(result?.Message, { type: "warning" });
                return;
            }
            setCharacterCount(result);
        } catch (error: any) {
            toast("Something went wrong! Contact Admin", { type: "warning" });
        }
    };

    const handleInputChange = (event: any) => {
        setInput(event.target.value);
    };

    return (
        <div className="app-container">
            <ToastContainer autoClose={3000} transition={Flip} />
            <div className="header-wrapper">
                <h2>Character Count</h2>
                <p>Enter a word or a sentence to find out number of occurance of a character</p>
            </div>

            <div className="input-wrapper">
                <input type="text" onChange={handleInputChange} />
                <button onClick={fetchCharacterCount}>Get Count</button>
            </div>
            <CharacterResult characterCount={characterCount} />
        </div>
    );
}

export default App;
