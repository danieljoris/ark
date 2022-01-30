from typing import Optional

from domain.enums.sex import Sex
from domain.enums.specie import Specie

from .core.entity import Entity


class Animal(Entity):
    name: str
    description: Optional[str] = None
    specie: Specie
    sex: Sex

    class Collection:
        name = "animals"
