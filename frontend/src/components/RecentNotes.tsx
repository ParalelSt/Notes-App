import type { Note } from "../types/noteItem";
import NoteItem from "./NoteItem";

const RecentNotes = () => {
  //For testing purposes

  const notes: Note[] = [
    {
      Id: 1,
      Title: "This is a note",
      Content: "",
    },

    {
      Id: 2,
      Title: "This is a note 2",
      Content: "",
    },

    {
      Id: 3,
      Title: "This is a note 3",
      Content: "",
    },

    {
      Id: 4,
      Title: "This is a note 4",
      Content: "",
    },
  ];

  //MAKE A COLOR PICKER LATER (a way to change the color so a note can stand out)

  return (
    <div className="flex flex-col">
      <h2 className="mb-3 text-base font-semibold">Recent Notes</h2>

      <div className="grid grid-cols-2 gap-6">
        {notes.map((n) => (
          <NoteItem key={n.Id} color="" note={n} />
        ))}
      </div>
    </div>
  );
};

export default RecentNotes;
