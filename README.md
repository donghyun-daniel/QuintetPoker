cat << EOF > README.md
# Quintet Poker

A simple poker game using FastAPI and SQLite.

## Setup

1. Install Poetry: \`curl -sSL https://install.python-poetry.org | python3 -\`
2. Install dependencies: \`poetry install\`
3. Run the application: \`poetry run uvicorn src.main:app --reload\`
4. Run tests: \`poetry run pytest\`
5. Format code: \`poetry run black .\`
6. Lint code: \`poetry run flake8 .\`
EOF
