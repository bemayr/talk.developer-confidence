data Vect : Nat -> Type -> Type where
    Nil  : Vect Z a
    (::) : a -> Vect k a -> Vect (S k) a

%name Vect xs, ys, zs

zipWith : (a -> b -> c) -> Vect n a -> Vect n b -> Vect n c
