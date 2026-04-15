const Nav = () => {
  return (
    <nav className="fixed bottom-0 left-0 right-0 w-full px-5 h-20 bg-nav-surface">
      <div className=" flex justify-center items-center w-full h-full">
        <button className="flex flex-1 justify-center py-2">
          <img
            className="stroke-black"
            src="./buttons/Notes.svg"
            alt="notes-button"
          />
        </button>
        <button className="flex flex-1 justify-center py-2">
          <img
            className="stroke-black"
            src="./buttons/Event.svg"
            alt="event-button"
          />
        </button>
        <button className="flex flex-1 justify-center  py-2">
          <img
            className="stroke-black"
            src="./buttons/Search.svg"
            alt="search-button"
          />
        </button>
        <button className="flex flex-1 justify-center  py-2">
          <img
            className="stroke-black"
            src="./buttons/Notes.svg"
            alt="notes-button"
          />
        </button>
      </div>
    </nav>
  );
};

export default Nav;
