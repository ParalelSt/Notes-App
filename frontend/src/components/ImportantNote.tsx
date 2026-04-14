const ImportantNote = () => {
  return (
    <div className={`flex flex-col w-full h-24 p-4 rounded-xl bg-surface`}>
      <h3 className="text-base text-text-primary font-semibold">Important</h3>
      <div className="w-full h-0.5 my-1.5 bg-border"></div>
      <span className="max-h-full text-sm leading-base overflow-hidden text-text-primary">
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Consequatur
        quasi, voluptatibus illo vel ex laborum tempore. Minus, quos porro
        molestias consectetur cupiditate officia assumenda eos alias ab nesciunt
        voluptatibus commodi.
      </span>
    </div>
  );
};

export default ImportantNote;
