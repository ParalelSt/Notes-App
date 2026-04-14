interface LayoutProps {
  children: React.ReactNode;
}

const Layout = ({ children }: LayoutProps) => {
  return (
    <div className="flex flex-col p-5 w-full h-screen bg-background">
      {children}
    </div>
  );
};

export default Layout;
