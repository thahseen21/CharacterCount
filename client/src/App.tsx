import { Flip, ToastContainer, Zoom, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import React, { useState } from "react";
import "./App.css";

type CharacterCount = {
    key: string;
    count: number;
};

const RenderTableContent = (value: any) => {
    return (
        <tr>
            <th>{value.value.key}</th>
            <td>{value.value.count}</td>
        </tr>
    );
};

// To avoid re-rendering when parent component changes
const RenderTableContentMemo = React.memo(RenderTableContent);

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

            {characterCount && characterCount.length > 0 && (
                <div className="result-wrapper">
                    <table>
                        <thead>
                            <tr>
                                <th>Character</th>
                                <th>Count</th>
                            </tr>
                        </thead>
                        <tbody>
                            {characterCount.map((x, index) => (
                                <RenderTableContentMemo value={x} key={index} />
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
        </div>
    );
}

export default App;
