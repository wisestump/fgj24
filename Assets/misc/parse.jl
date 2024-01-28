using CSV, DataFrames

file = CSV.read("LeGang GGJ24 - IN GAME TEXTS.csv", DataFrame) |> Matrix


output = "";

function parse_file(file)
    output = ""
    dialog_index = 0;
    duration = "0.5f";
    gap = 1;
    for row ∈ eachrow(file[2:end, :])
        if !ismissing(row[1])
            dialog_index = 0;
            output *= "}}, "
            output *= "{\"$(row[1])\", new List<Phrase>() {"
        end

        if ismissing(row[2])
            actor = "narrator"
        elseif row[2] == "Claw"
            actor = "claw"
        else
            actor = "plushie"
        end

        output *= "new Phrase($(gap*dialog_index), $actor, \"$(row[3])\", $duration),\n"
        dialog_index += 1
    end
    return output * "}"
end

output = parse_file(file)

println(output)