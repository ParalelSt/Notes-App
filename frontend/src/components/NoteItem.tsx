import { Link } from "react-router-dom";
import type { Note } from "../types/noteItem";

interface NoteItemProps {
  color?: string;
  note: Note;
}

const NoteItem = ({ color, note }: NoteItemProps) => {
  return (
    <Link
      to={"/"}
      className={`flex flex-col max-w-50 w-full h-50 p-4 rounded-xl ${color ? color : "bg-surface"} border focus:border-blue-600 border-transparent`}
    >
      <h3 className="text-base text-text-primary font-semibold">
        {note.Title}
      </h3>
      <div className="w-full h-0.5 my-1.5 bg-border"></div>
      <span className="max-h-full text-sm leading-base overflow-hidden text-text-primary">
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Consequatur
        quasi, voluptatibus illo vel ex laborum tempore. Minus, quos porro
        molestias consectetur cupiditate officia assumenda eos alias ab nesciunt
        voluptatibus commodi.
      </span>
    </Link>
  );
};

export default NoteItem;
