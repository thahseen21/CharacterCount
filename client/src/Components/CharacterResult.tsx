import "react-toastify/dist/ReactToastify.css";
import React, { useState } from "react";

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

function CharacterResult(props: CharacterResult) {
    return (
        <>
            {props.characterCount && props.characterCount.length > 0 && (
                <div className="result-wrapper">
                    <table>
                        <thead>
                            <tr>
                                <th>Character</th>
                                <th>Count</th>
                            </tr>
                        </thead>
                        <tbody>
                            {props.characterCount.map((x, index) => (
                                <RenderTableContentMemo value={x} key={x.key} />
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
        </>
    );
}

export type CharacterResult = {
    characterCount: CharacterCount[];
};

export default CharacterResult;
